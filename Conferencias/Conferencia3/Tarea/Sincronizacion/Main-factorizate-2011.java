import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;
import java.util.ArrayList;
/**
 *
 * @author aefernandez
 */
class Main {

    /**
     * @param args the command line arguments
     */

    static boolean[] composites;

    static ArrayList<Integer> factors, exps, factorsInLcm,expsInLcm;
    static void InitializeErathostenes(int n)
    {
        composites = new boolean[n+1];
        int sqrt = (int)Math.ceil(Math.sqrt(n));
        for(int i = 2; i <= sqrt;i++)
            if(!composites[i])
                for(int j = i+i;j <= n; j+=i)
                    composites[j] = true;
    }

    static void Facotorizate(int n)
    {
        factors.clear();
        exps.clear();
        if(!composites[n])
        {
            factors.add(n);
            exps.add(1);
        }
        else
        {
            int c;
            for(int i = 2; n > 1; i++)
                if(!composites[i] && n % i == 0)
                {
                    c = 0;
                    for(int j = i; n % i == 0; j+=i)
                    {
                        c++;
                        n /= i;
                    }
                    factors.add(i);
                    exps.add(c);
                }
         }
    }

    static void UpdateLCM_FactorsAndExps()
    {
        int i = 0,index,max;
        for(Integer factor:factors)
        {
            index = factorsInLcm.indexOf(factor);
            if(index == -1)
            {
                factorsInLcm.add(factor);
                expsInLcm.add(exps.get(i));
            }
            else
            {
                max = Math.max(exps.get(i), expsInLcm.get(index));
                expsInLcm.set(index, max);
            }
            i++;
        }
    }

    static BigInteger LCM()
    {
        int i = 0;
        BigInteger lcm = BigInteger.ONE,b;
        for(Integer factor:factorsInLcm)
        {
            b = new BigInteger(factor+"");
            lcm = lcm.multiply(b.pow(expsInLcm.get(i)));
            i++;
        }
        return lcm;
    }

    
    public static void main(String[] args) throws IOException {
        InitializeErathostenes(10000);
        boolean[] mark = new boolean[10001];
        int[] frequency = new int[10001];
        String[] arr;
        factors = new ArrayList<Integer>();
        exps = new ArrayList<Integer>();
        factorsInLcm = new ArrayList<Integer>();
        expsInLcm = new ArrayList<Integer>();
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int cases = Integer.parseInt(br.readLine()), n, k;
        while(cases-- >0)
        {
            factorsInLcm.clear();
            expsInLcm.clear();
            n = Integer.parseInt(br.readLine());
            arr = br.readLine().split(" ");
            mark[0] = true;
            for(int i = 0; i < n; i++)
            {
                frequency[i] = k = Integer.parseInt(arr[i]);
                if(!mark[k])
                {
                    mark[k] = true;
                    Facotorizate(k);
                    UpdateLCM_FactorsAndExps();
                }
            }
            for(int i = 0; i < n; i++)
                mark[frequency[i]] = false;
            System.out.println(LCM());
        }
    }

}
