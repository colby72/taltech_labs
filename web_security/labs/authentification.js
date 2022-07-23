const config = require('../config').authentication;
const UserService = require('../services/user-service');

module.exports = class Authentication {
  constructor(server) {
    this.server = server;
    this.userService = new UserService();
  }

  async setupAuthentication(server) {
    await this.server.auth.strategy('session', 'cookie', {
      cookie: {
        name: 'token',
        path: '/',
        password: config.secret,
        // For working via HTTP in localhost
        isSecure: false,
        isHttpOnly: false,
      },

      validateFunc: async (request, session) => {
        const account = await this.userService.getUserById(session.id);
        if (!account) {
          return { valid: false };
        }

        return { valid: true, credentials: account };
      },
    });
    await server.auth.default('session');
  }
};

setcookie('username','Peter',0,'/','www.example.com',null,true);
if ($_SESSION['admin'] || $_REQUEST['id']===$_SESSION['user']['id']){
				edit_profile($_REQUEST['id']);
			} else {
				$_SESSION['alerts'][] = "Restricted access";
				header("Location: ?");
				exit(0);
}
https://25084f5b688527ffaff789b5.europa.lab.rangeforce.com/result.php?rollid=3&class=1
https://25084f5b688527ffaff789b5.europa.lab.rangeforce.com/deletecomment.php?commentid=10
