import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;

/**
 *
 * @author aefernandez
 */
class Principal {

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int cant, mitad, piv;
        BigInteger dos = new BigInteger("2");
        BigInteger[] count = new BigInteger[1001];
        count[0] = count[1] = BigInteger.ONE;
        for (int i = 2; i <= 1000; i++) 
        {
            count[i] = BigInteger.ZERO;
            piv = i - 1;
            mitad = piv / 2;
            if (piv % 2 == 1)
                mitad++;
            else
                count[i] = count[i].add(count[mitad].multiply(count[mitad]));
            for (int j = 0; j < mitad; j++)
                count[i] = count[i].add(dos.multiply(count[j].multiply(count[piv - j])));
        }
        cant = Integer.parseInt(br.readLine());
        while(cant-- > 0)
            System.out.println(count[Integer.parseInt(br.readLine())]);
    }
}