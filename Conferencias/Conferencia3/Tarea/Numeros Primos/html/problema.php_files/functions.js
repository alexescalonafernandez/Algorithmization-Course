/*******************************************************************
bbCode control by subBlue design [ www.subBlue.com ]
Includes unixsafe colour palette selector by SHS
edited by: Shedrock - The Theme Guru
*******************************************************************/
// Startup variables
var imageTag = false;
var theSelection = false;
// Check for Browser & Platform for PC & IE specific bits
// More details from: http://www.mozilla.org/docs/web-developer/sniffer/browser_type.html
var clientPC = navigator.userAgent.toLowerCase(); // Get client info
var clientVer = parseInt(navigator.appVersion); // Get browser version
var is_ie = ((clientPC.indexOf('msie') != -1) && (clientPC.indexOf('opera') == -1));
var is_nav = ((clientPC.indexOf('mozilla') != -1) && (clientPC.indexOf('spoofer') == -1) && (clientPC.indexOf('compatible') == -1) && (clientPC.indexOf('opera') == -1) && (clientPC.indexOf('webtv') == -1) && (clientPC.indexOf('hotjava') == -1));
var is_win = ((clientPC.indexOf('win') != -1) || (clientPC.indexOf('16bit') != -1));
var is_mac = (clientPC.indexOf('mac') != -1);


/*******************************************************************
Apply bbcodes
*******************************************************************/
var form_name = 'shoutform';
var text_name = 'shout_message';
function fuzecolor(bbopen, bbclose) {
	theSelection = false;
	document.forms[form_name].elements[text_name].focus();
	if ((clientVer >= 4) && is_ie && is_win) {
		// Get text selection
		theSelection = document.selection.createRange().text;
		if (theSelection) {
			// Add tags around selection
			document.selection.createRange().text = bbopen + theSelection + bbclose;
			document.forms[form_name].elements[text_name].focus();
			theSelection = '';
			return;
		}
	} else if (document.forms[form_name].elements[text_name].selectionEnd && (document.forms[form_name].elements[text_name].selectionEnd - document.forms[form_name].elements[text_name].selectionStart > 0)) {
		mozWrap(document.forms[form_name].elements[text_name], bbopen, bbclose);
		document.forms[form_name].elements[text_name].focus();
		theSelection = '';
		return;
	}
	// Close image tag before adding
	if (imageTag) {
		insert_text(bbtags[15]);
		// Remove the close image tag from the list
		lastValue = arraypop(bbcode) - 1;
		// Return button back to normal state
		document.forms[form_name].addbbcode14.value = 'Img';
		imageTag = false;
	}
	// Open tag
	insert_text(bbopen + bbclose);
	document.forms[form_name].elements[text_name].focus();
	storeCaret(document.forms[form_name].elements[text_name]);
	return;
}

/*******************************************************************
Insert text at position
*******************************************************************/
function insert_text(text) {
	if (document.forms[form_name].elements[text_name].createTextRange && !isNaN(document.forms[form_name].elements[text_name].caretPos)) {
		var caretPos = document.forms[form_name].elements[text_name].caretPos;
		caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == ' ' ? caretPos.text + text + ' ' : caretPos.text + text;
	} else if (!isNaN(document.forms[form_name].elements[text_name].selectionStart)) {
		var selStart = document.forms[form_name].elements[text_name].selectionStart;
		var selEnd = document.forms[form_name].elements[text_name].selectionEnd;
		mozWrap(document.forms[form_name].elements[text_name], text, '')
		document.forms[form_name].elements[text_name].selectionStart = selStart + text.length;
		document.forms[form_name].elements[text_name].selectionEnd = selEnd + text.length;
	} else {
		document.forms[form_name].elements[text_name].value = document.forms[form_name].elements[text_name].value + text;
	}
}

/*******************************************************************
bbstyle
*******************************************************************/
function bbstyle(bbnumber) {
	donotinsert = false;
	theSelection = false;
	bblast = 0;
	document.forms[form_name].elements[text_name].focus();
	// Close all open tags & default button names
	if (bbnumber == -1) {
		while (bbcode[0]) {
			butnumber = arraypop(bbcode) - 1;
			document.forms[form_name].elements[text_name].value += bbtags[butnumber + 1];
			buttext = eval('document.forms[form_name].addbbcode' + butnumber + '.value');
			if (buttext != '[*]') {
				eval('document.forms[form_name].addbbcode' + butnumber + '.value ="' + buttext.substr(0,(buttext.length - 1)) + '"');
			}
		}
		document.forms[form_name].addbbcode10.value = 'List';
		bbtags[10] = '[list]';
		document.forms[form_name].addbbcode12.value = 'List=';
		bbtags[12] = '[list=]';
		// All tags are closed including image tags :D
		imageTag = false;
		document.forms[form_name].elements[text_name].focus();
		return;
	}
	// [*] doesn't have an end tag
	noEndTag = (bbtags[bbnumber] == '[*]')
	if ((clientVer >= 4) && is_ie && is_win) {
		// Get text selection
		theSelection = document.selection.createRange().text;
		if (theSelection) {
			// Add tags around selection
			document.selection.createRange().text = bbtags[bbnumber] + theSelection + ((!noEndTag) ? bbtags[bbnumber+1] : '');
			document.forms[form_name].elements[text_name].focus();
			theSelection = '';
			return;
		}
	} else if (document.forms[form_name].elements[text_name].selectionEnd && (document.forms[form_name].elements[text_name].selectionEnd - document.forms[form_name].elements[text_name].selectionStart > 0)) {
		mozWrap(document.forms[form_name].elements[text_name], bbtags[bbnumber], ((!noEndTag) ? bbtags[bbnumber+1] : ''));
		document.forms[form_name].elements[text_name].focus();
		theSelection = '';
		return;
	}
	// Find last occurance of an open tag the same as the one just clicked
	for (i = 0; i < bbcode.length; i++) {
		if (bbcode[i] == bbnumber+1) {
			bblast = i;
			donotinsert = true;
		}
	}
	if (bbnumber == 10 && bbtags[10] != '[*]') {
		if (donotinsert) {
			document.forms[form_name].addbbcode12.value = 'List=';
			tmp_help = o_help;
			o_help = e_help;
			e_help = tmp_help;
			bbtags[12] = '[list=]';
		} else {
			document.forms[form_name].addbbcode12.value = '[*]';
			tmp_help = o_help;
			o_help = e_help;
			e_help = tmp_help;
			bbtags[12] = '[*]';
		}
	}
	if (bbnumber == 12 && bbtags[12] != '[*]') {
		if (donotinsert) {
			document.forms[form_name].addbbcode10.value = 'List';
			tmp_help = l_help;
			l_help = e_help;
			e_help = tmp_help;
			bbtags[10] = '[list]';
		} else {
			document.forms[form_name].addbbcode10.value = '[*]';
			tmp_help = l_help;
			l_help = e_help;
			e_help = tmp_help;
			bbtags[10] = '[*]';
		}
	}
	// Close all open tags up to the one just clicked & default button names
	if (donotinsert) {
		while (bbcode[bblast]) {
			butnumber = arraypop(bbcode) - 1;
			if (bbtags[butnumber] != '[*]') {
				insert_text(bbtags[butnumber + 1]);
			} else {
				insert_text(bbtags[butnumber]);
			}
			buttext = eval('document.forms[form_name].addbbcode' + butnumber + '.value');
			if (bbtags[butnumber] != '[*]') {
				eval('document.forms[form_name].addbbcode' + butnumber + '.value ="' + buttext.substr(0,(buttext.length - 1)) + '"');
			}
			imageTag = false;
		}
		document.forms[form_name].elements[text_name].focus();
		return;
	} else {
		// Open tags
		// Close image tag before adding another
		if (imageTag && (bbnumber != 14)) {
			insert_text(bbtags[15]);
			// Remove the close image tag from the list
			lastValue = arraypop(bbcode) - 1;
			// Return button back to normal state
			document.forms[form_name].addbbcode14.value = 'Img';
			imageTag = false;
		}
		// Open tag
		insert_text(bbtags[bbnumber]);
		// Check to stop additional tags after an unclosed image tag
		if (bbnumber == 14 && imageTag == false) { imageTag = 1; }
		if (bbtags[bbnumber] != '[*]') {
			arraypush(bbcode, bbnumber + 1);
			eval('document.forms[form_name].addbbcode'+bbnumber+'.value += "*"');
		}
		document.forms[form_name].elements[text_name].focus();
		return;
	}
	storeCaret(document.forms[form_name].elements[text_name]);
}

/*******************************************************************
From http://www.massless.org/mozedit/
*******************************************************************/
function mozWrap(txtarea, open, close) {
	var selLength = txtarea.textLength;
	var selStart = txtarea.selectionStart;
	var selEnd = txtarea.selectionEnd;
	var scrollTop = txtarea.scrollTop;
	if (selEnd == 1 || selEnd == 2) { selEnd = selLength; }
	var s1 = (txtarea.value).substring(0,selStart);
	var s2 = (txtarea.value).substring(selStart, selEnd)
	var s3 = (txtarea.value).substring(selEnd, selLength);
	txtarea.value = s1 + open + s2 + close + s3;
	txtarea.selectionStart = selEnd + open.length + close.length;
	txtarea.selectionEnd = txtarea.selectionStart;
	txtarea.focus();
	txtarea.scrollTop = scrollTop;
	return;
}

/*******************************************************************
Insert at Claret position. Code from
http://www.faqts.com/knowledge_base/view.phtml/aid/1052/fid/130
*******************************************************************/
function storeCaret(textEl) {
	if (textEl.createTextRange) {
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}

/*******************************************************************
Check message length
*******************************************************************/
function checkForm() {
	if (document.post.message.value.length < 6) {
		alert('You must enter a message when posting.');
		return false;
	} else { return true; }
}

/*******************************************************************
InsertText Function
*******************************************************************/
function fuzetext(elname, wrap1, wrap2) {
	if (document.selection) { // for IE
		var str = document.selection.createRange().text;
		document.forms['shoutform'].elements[elname].focus();
		var sel = document.selection.createRange();
		sel.text = wrap1 + str + wrap2;
		return;
	} else if ((typeof document.forms['shoutform'].elements[elname].selectionStart) != 'undefined') { // for Mozilla
		var txtarea = document.forms['shoutform'].elements[elname];
		var selLength = txtarea.textLength;
		var selStart = txtarea.selectionStart;
		var selEnd = txtarea.selectionEnd;
		var oldScrollTop = txtarea.scrollTop;
		//if (selEnd == 1 || selEnd == 2)
		//selEnd = selLength;
		var s1 = (txtarea.value).substring(0,selStart);
		var s2 = (txtarea.value).substring(selStart, selEnd)
		var s3 = (txtarea.value).substring(selEnd, selLength);
		txtarea.value = s1 + wrap1 + s2 + wrap2 + s3;
		txtarea.selectionStart = s1.length;
		txtarea.selectionEnd = s1.length + s2.length + wrap1.length + wrap2.length;
		txtarea.scrollTop = oldScrollTop;
		txtarea.focus();
		return;
	} else {
		insertText(elname, wrap1 + wrap2);
	}
}

function insertText(elname, what, formname) {
	if (document.forms[formname].elements[elname].createTextRange) {
		document.forms[formname].elements[elname].focus();
		document.selection.createRange().duplicate().text = what;
	} else if ((typeof document.forms[formname].elements[elname].selectionStart) != 'undefined') { // for Mozilla
		var tarea = document.forms[formname].elements[elname];
		var selEnd = tarea.selectionEnd;
		var txtLen = tarea.value.length;
		var txtbefore = tarea.value.substring(0,selEnd);
		var txtafter = tarea.value.substring(selEnd, txtLen);
		var oldScrollTop = tarea.scrollTop;
		tarea.value = txtbefore + what + txtafter;
		tarea.selectionStart = txtbefore.length + what.length;
		tarea.selectionEnd = txtbefore.length + what.length;
		tarea.scrollTop = oldScrollTop;
		tarea.focus();
	} else {
		document.forms[formname].elements[elname].value += what;
		document.forms[formname].elements[elname].focus();
	}
}

/*******************************************************************
Show more shouts function
*******************************************************************/
function defuze(msg_id) {
	msg_id.style.display=msg_id.style.display=='none' ? '' : 'none'
}

/*******************************************************************
Text Limiter
*******************************************************************/
function textCounter(field, countfield, maxlimit) {
	if (field.value.length > maxlimit) { // if too long...trim it!
		field.value = field.value.substring(0, maxlimit);
	// otherwise, update 'characters left' counter
	} else { countfield.value = maxlimit - field.value.length; }
}

/*******************************************************************
Close popup on new window load
*******************************************************************/
function ChangeMenu(file){
    top.opener.window.location.href = file;
	window.close();
}

/*******************************************************************
AJAX functions
*******************************************************************/
var request;
var queryString;
var actionString;
function setQueryString(reqFor, xtraParam) {
	queryString = "basedir=" + encodeURIComponent(basedir) + "&fusion_self=" + encodeURIComponent(fusion_self) + "&";
	if (reqFor == "refresh") {
		actionString = "sb_action=refresh";
	} else if (reqFor == "shout") {
		actionString = "sb_action=shout&";
		var frm = document.shoutform;
		var numberElements = frm.elements.length;
		for(var i = 0; i < numberElements; i++) {
			actionString += frm.elements[i].name + "=" + encodeURIComponent(frm.elements[i].value);
			if (i < numberElements - 1) {
				actionString += "&";
			}
		}
		actionString += "&aid=" + encodeURIComponent(aid);
 	} else if (reqFor == "edit") {
		actionString = "sb_action=edit&shout_id=" + encodeURIComponent(xtraParam) + "&aid=" + encodeURIComponent(aid);
 	} else if (reqFor == "delete") {
		actionString = "sb_action=delete&shout_id=" + encodeURIComponent(xtraParam) + "&aid=" + encodeURIComponent(aid);
	} else if (reqFor == "ban") {
		actionString = "sb_action=ban&uid=" + encodeURIComponent(xtraParam) + "&aid=" + encodeURIComponent(aid);
	} else if (reqFor == "unban") {
		actionString = "sb_action=unban&uid=" + encodeURIComponent(xtraParam) + "&aid=" + encodeURIComponent(aid);
	}
	queryString += actionString;
}

function sendData(reqFor, xtraParam) {
	setQueryString(reqFor, xtraParam);
	var url = pageURL;
	if (reqFor == "shout" || reqFor == "edit") {
		document.getElementById("sb_form").innerHTML = waitText;;
	}
	httpRequest("POST", url, true, reqFor);
}

function initReq(reqType, url, isAsynch, reqFor) {
	if (reqFor == "edit") {
		reqUpdate = document.getElementById("sb_form");
	} else if (reqFor == "shout") {
		reqUpdate = document.getElementById("sb_form_and_display");
	} else {
		reqUpdate = document.getElementById("sb_display");
	}
	request.onreadystatechange = function() {
		if (request.readyState == 4) {
			if (request.status == 200) {
				reqUpdate.innerHTML = request.responseText;
				if (reqFor == "shout") {
					if (document.shoutform.shout_name) {
						document.shoutform.shout_name.value = "";
					}
					document.shoutform.shout_message.value = "";
					document.shoutform.shout_message.focus();
				} else if (reqFor == "edit") {
					document.shoutform.shout_message.focus();
				}
			} else {
				if (reqFor == "shout") {
					document.shoutform.action = altSubmit;
					document.shoutform.submit();
				} else {
					if (reqFor == "edit") {
						location.href = admin + "?" + actionString;
					} else {
						location.href = (altSubmit == fusion_self ? fusion_self + "?" + actionString : altSubmit + "&" + actionString);
					}
				}
			}
		}
	}
	request.open(reqType, url, isAsynch);
	request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
	request.send(queryString);
}

function httpRequest(reqType, url, asynch, reqFor) {
	if (window.XMLHttpRequest) {
		request = new XMLHttpRequest();
	} else if (window.ActiveXObject) {
		request = new ActiveXObject("Msxml2.XMLHTTP");
		if (! request) {
			request = new ActiveXObject("Microsoft.XMLHTTP");
		}
	}
	if (request) {
		initReq(reqType, url, asynch, reqFor);
	} else {
		if (reqFor == "shout") {
			document.shoutform.action = altSubmit;
			document.shoutform.submit();
		} else {
			if (reqFor == "edit") {
				location.href = admin + "?" + actionString;
			} else {
				location.href = (altSubmit == fusion_self ? fusion_self + "?" + actionString : altSubmit + "&" + actionString);
			}
		}
	}
}

function shoutbox_refresh(){
	sendData("refresh", "");
	setTimeout("shoutbox_refresh()", 20000);
}
/*60000*/