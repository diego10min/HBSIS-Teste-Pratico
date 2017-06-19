"use strict";
var usuarios_component_1 = require('./usuarios-component');
exports.UsuariosRoutes = [
    {
        path: 'usuario',
        component: usuarios_component_1.UsuariosComponent
    },
    {
        path: '',
        redirectTo: '/usuario',
        terminal: true
    }
];
//# sourceMappingURL=usuarios-routes.js.map