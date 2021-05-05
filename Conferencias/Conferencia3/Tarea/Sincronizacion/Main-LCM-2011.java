import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;

/**
 *
 * @author aefernandez
 */
class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int cases = Integer.parseInt(br.readLine()),n;
        boolean[] mark = new boolean[10001];
        int[] frequency = new int[10001];
        BigInteger lcm, gcd, f;
        String[] arr;
        while(cases-- >0)
        {
            n = Integer.parseInt(br.readLine());
            arr = br.readLine().split(" ");
            for(int i = 0; i < n; i++)
                frequency[i] = Integer.parseInt(arr[i]);
            mark[0] = true;
            lcm = BigInteger.ONE;
            for(int i = 0; i < n; i++)
                if(!mark[frequency[i]])
                {
                    mark[frequency[i]] = true;
                    f = new BigInteger(arr[i]);
                    gcd = f.gcd(lcm);
                    lcm = lcm.multiply(f.divide(gcd));
                }
            for(int i = 0; i < n; i++)
                mark[frequency[i]] = false;
            System.out.println(lcm);
        }
    }

}