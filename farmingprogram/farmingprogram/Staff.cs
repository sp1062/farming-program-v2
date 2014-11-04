using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmingprogram
{
    class Staff
    {
        private String username, password;
        private int rights;

        public Staff(String username, String password, int rights)
        {
            this.username = username;
            this.password = password;
            this.rights = rights;
        }

        public int getRights()
        {
            return rights;
        }

        public String getUsername()
        {
            return username;
        }

        public String getPassword()
        {
            return password;
        }

    }
}
