"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var usuario_1 = require('../.././models/usuario');
var usuario_service_1 = require('../.././services/usuario-service');
var router_1 = require('@angular/router');
var modal_util_component_1 = require('../utils/modal-util-component');
var modal_persiste_usuario_component_1 = require('./modal-persiste-usuario-component');
var UsuariosComponent = (function () {
    function UsuariosComponent(router, usuarioService) {
        this.router = router;
        this.usuarioService = usuarioService;
    }
    UsuariosComponent.prototype.showModal = function (usu) {
        this.msgErro = "";
        if (usu) {
            this.usuario = JSON.parse(JSON.stringify(usu));
        }
        else {
            this.usuario = new usuario_1.Usuario();
        }
    };
    UsuariosComponent.prototype.onAtualizaUsuarios = function (usu) {
        this.usuarios = usu;
    };
    UsuariosComponent.prototype.listarTodos = function () {
        var _this = this;
        this.usuarioService.listarTodos()
            .subscribe(function (usuarios) { return _this.usuarios = usuarios; }, function (error) { return _this.msgErro = error; });
    };
    UsuariosComponent.prototype.ngOnInit = function () {
        this.listarTodos();
    };
    UsuariosComponent.prototype.excluir = function (id) {
        this.idExcluir = id;
    };
    UsuariosComponent.prototype.onExcluir = function () {
        var _this = this;
        this.usuarioService.excluir(this.idExcluir)
            .subscribe(function (data) { return _this.listarTodos(); }, function (error) { return _this.msgErro = error; });
        this.idExcluir = -1;
    };
    UsuariosComponent.prototype.atualizar = function () {
        var _this = this;
        this.usuarioService.atualizar(this.usuario)
            .subscribe(function (usuario) { return _this.router.navigate(['/usuario']); }, function (error) { return _this.msgErro = error; });
    };
    UsuariosComponent = __decorate([
        core_1.Component({
            selector: 'usuario',
            templateUrl: 'app/views/usuario/usuario.html',
            providers: [usuario_service_1.UsuarioService],
            directives: [router_1.ROUTER_DIRECTIVES, modal_util_component_1.ModalUtilComponent, modal_persiste_usuario_component_1.ModalPersisteUsuarioComponent]
        }), 
        __metadata('design:paramtypes', [router_1.Router, usuario_service_1.UsuarioService])
    ], UsuariosComponent);
    return UsuariosComponent;
}());
exports.UsuariosComponent = UsuariosComponent;
//# sourceMappingURL=usuarios-component.js.map