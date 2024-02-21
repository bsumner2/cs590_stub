namespace BulletinBoard_Api.Services;

public class TrafficTestingService : ITrafficTestingService {
    
    

    public async Task<IEnumerable<int>> SieveOfEratosthenese(int upperLim) {
        bool[] isPrime = new bool[upperLim+1];
        SortedSet<int> ret = new();
        await Task.Run(()=>{
        for (int i = 2; i <= upperLim; ++i)
            isPrime[i] = true;
        int sqrtLim = (int)Math.Sqrt(upperLim);
        for (int i = 2; i <= sqrtLim; ++i) {
            if (isPrime[i])
                for (int j = i*i; j <= upperLim; j += i)
                    isPrime[j] = false;
        }
        
        for (int i = 2; i <= upperLim; ++i)
            if (isPrime[i])
                ret.Add(i);});
        return ret;

    }


}