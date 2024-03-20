using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    public partial class Solutions
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> stores = new Dictionary<int, int>();
            for (int i = 0; i< nums.Length; i++)
            {
                var result = target - nums[i];
                if (stores.ContainsKey(result))
                    return new int[] { i, stores[result] };
                stores[nums[i]] = i;
            }
            return Array.Empty<int>();
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            
            for (int i = 0; i <= nums.Length; i++)
            {
                for(int j=i+1; j<nums.Length; j++)
                {
                    if ((target - (nums[j] + nums[i]) == 0))
                    {
                        return new int[] { i,j };
                    }
                }    
            }
            return Array.Empty<int>();
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList< int >> result = new List<IList<int>>();
            Array.Sort(nums);
            
            for(int i = 0; i<nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int j = i + 1;
                int k = nums.Length - 1;

                while(j < k)
                {
                    var r0 = nums[i] + nums[j] + nums[k];
                    
                    if(r0 == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        while (j < k && nums[j] == nums[j + 1])
                        {
                            j++;
                        }
                        while (j < k && nums[k] == nums[k - 1])
                        {
                            k--;
                        }
                        j++;
                        k--;
                    }
                    else if(r0 > 0)
                    {
                        k--;
                    }else if(r0 < 0)
                    {
                        j++;
                    }
                }
            }

            return result;
            
        }
       
    }
}
