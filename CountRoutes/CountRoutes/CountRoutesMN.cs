using System;
using System.Collections.Generic;
using System.Text;

namespace CountRoutes
{
    static class CountRoutesMN
    {
        public static int N { get; set; }
        public static int M { get; set; }

        public static int recursionCountRoutes(int m, int n)
        {
            if (m == 0 || n == 0)
            {
                return 0;
            }
            if (m == 1 && n == 1)
            {
                return 1;
            }
            return recursionCountRoutes(m, n - 1) + recursionCountRoutes(m - 1, n);

        }
    }
}
