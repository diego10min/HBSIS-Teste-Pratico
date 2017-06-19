"use strict";
var router_1 = require('@angular/router');
var usuarios_routes_1 = require('./components/usuarios/usuarios-routes');
exports.routes = usuarios_routes_1.UsuariosRoutes.slice();
exports.APP_ROUTER_PROVIDERS = [
    router_1.provideRouter(exports.routes)
];
//# sourceMappingURL=app-routes.js.map