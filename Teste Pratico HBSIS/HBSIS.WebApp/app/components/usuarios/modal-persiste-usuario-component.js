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
var ModalPersisteUsuarioComponent = (function () {
    function ModalPersisteUsuarioComponent(router, usuarioService) {
        this.router = router;
        this.usuarioService = usuarioService;
        this.atualizaUsuarios = new core_1.EventEmitter();
    }
    ModalPersisteUsuarioComponent.prototype.ngOnInit = function () {
        this.usuario = new usuario_1.Usuario();
    };
    ModalPersisteUsuarioComponent.prototype.persisteUsuario = function () {
        var _this = this;
        if (this.usuario.id_Usuario > 0) {
            this.usuarioService.atualizar(this.usuario)
                .subscribe(function (usuarios) { return _this.sucessoPersiste(usuarios); }, function (error) { return _this.msgErro = error; });
        }
        else {
            this.usuarioService.cadastrar(this.usuario)
                .subscribe(function (usuarios) { return _this.sucessoPersiste(usuarios); }, function (error) { return _this.msgErro = error; });
        }
    };
    ModalPersisteUsuarioComponent.prototype.fecharModal = function () {
        this.msgErro = "";
        jQuery("#modalPersisteUsuario").modal("hide");
    };
    ModalPersisteUsuarioComponent.prototype.sucessoPersiste = function (usu) {
        this.fecharModal();
        this.atualizaUsuarios.emit(usu);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], ModalPersisteUsuarioComponent.prototype, "msgErro", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', usuario_1.Usuario)
    ], ModalPersisteUsuarioComponent.prototype, "usuario", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], ModalPersisteUsuarioComponent.prototype, "id", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], ModalPersisteUsuarioComponent.prototype, "titulo", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', core_1.EventEmitter)
    ], ModalPersisteUsuarioComponent.prototype, "atualizaUsuarios", void 0);
    ModalPersisteUsuarioComponent = __decorate([
        core_1.Component({
            selector: 'modal-persiste-usuario',
            templateUrl: 'app/views/usuario/usuario-modal-persiste.html',
            providers: [usuario_service_1.UsuarioService]
        }),
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router, usuario_service_1.UsuarioService])
    ], ModalPersisteUsuarioComponent);
    return ModalPersisteUsuarioComponent;
}());
exports.ModalPersisteUsuarioComponent = ModalPersisteUsuarioComponent;
//# sourceMappingURL=modal-persiste-usuario-component.js.map