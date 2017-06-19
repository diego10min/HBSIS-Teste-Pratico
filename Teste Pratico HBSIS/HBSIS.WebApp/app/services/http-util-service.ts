import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import {GlobalSettings} from '.././constant/globalSettings';

@Injectable()
export class HttpUtilService {

	url(path: string) {
		return GlobalSettings.API_ADDRESS + path;
	}

	headers() {
		let headersParams = { 'Content-Type': 'application/json' };
		let headers = new Headers(headersParams);
    	let options = new RequestOptions({ headers: headers });
    	return options;
	}

	extrairDados(response: Response) {

		if(response.status == 204)
			return {};
		
    	let data = response.json();
    	return data || {};
  	}

  	processarErros(erro: any) {
		let erroPadrao = "Erro acessando servidor remoto.";
		let listaErroRetorno : any = [];

		if(erro && erro._body){
			listaErroRetorno = JSON.parse(erro._body);
		}

		if(listaErroRetorno && listaErroRetorno.length > 0){
			erroPadrao = "";
			for(let msg of listaErroRetorno){
				erroPadrao = erroPadrao + msg.message + "<br/>";
			}
		}

	    return Observable.throw(erroPadrao);
	}
}