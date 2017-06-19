"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var UsuarioModel = (function () {
    function UsuarioModel() {
    }
    return UsuarioModel;
}());
exports.UsuarioModel = UsuarioModel;
var Usuario = (function (_super) {
    __extends(Usuario, _super);
    function Usuario() {
        _super.call(this);
        this.id_Usuario = 0;
        this.nome = '';
        this.documento = '';
        this.telefone = '';
    }
    return Usuario;
}(UsuarioModel));
exports.Usuario = Usuario;
//# sourceMappingURL=usuario.js.map