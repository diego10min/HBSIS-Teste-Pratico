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
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
var globalSettings_1 = require('.././constant/globalSettings');
var HttpUtilService = (function () {
    function HttpUtilService() {
    }
    HttpUtilService.prototype.url = function (path) {
        return globalSettings_1.GlobalSettings.API_ADDRESS + path;
    };
    HttpUtilService.prototype.headers = function () {
        var headersParams = { 'Content-Type': 'application/json' };
        var headers = new http_1.Headers(headersParams);
        var options = new http_1.RequestOptions({ headers: headers });
        return options;
    };
    HttpUtilService.prototype.extrairDados = function (response) {
        if (response.status == 204)
            return {};
        var data = response.json();
        return data || {};
    };
    HttpUtilService.prototype.processarErros = function (erro) {
        var erroPadrao = "Erro acessando servidor remoto.";
        var listaErroRetorno = [];
        if (erro && erro._body) {
            listaErroRetorno = JSON.parse(erro._body);
        }
        if (listaErroRetorno && listaErroRetorno.length > 0) {
            erroPadrao = "";
            for (var _i = 0, listaErroRetorno_1 = listaErroRetorno; _i < listaErroRetorno_1.length; _i++) {
                var msg = listaErroRetorno_1[_i];
                erroPadrao = erroPadrao + msg.message + "<br/>";
            }
        }
        return Observable_1.Observable.throw(erroPadrao);
    };
    HttpUtilService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], HttpUtilService);
    return HttpUtilService;
}());
exports.HttpUtilService = HttpUtilService;
//# sourceMappingURL=http-util-service.js.map