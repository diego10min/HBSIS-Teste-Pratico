import { Injectable } from '@angular/core';
import { Usuario } from '../models/usuario';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpUtilService } from './http-util-service';

@Injectable()
export class UsuarioService {

	private path = 'usuario';

	constructor(private http: Http, private httpUtil: HttpUtilService) {
	}

	listarTodos(): Observable<Usuario[]> {

		return this.http.get(this.httpUtil.url(this.path), this.httpUtil.headers())
	                .map(this.httpUtil.extrairDados)
	                .catch(this.httpUtil.processarErros);
	}

	cadastrar(usuario: Usuario): Observable<Usuario> {
		let params = JSON.stringify(usuario);

    	return this.http.post(this.httpUtil.url(this.path + "/new"), params, 
    					this.httpUtil.headers())
      				.map(this.httpUtil.extrairDados)
	                .catch(this.httpUtil.processarErros); 
	}

	atualizar(usuario: Usuario) {
		let params = JSON.stringify(usuario);

    	return this.http.post(this.httpUtil.url(this.path + "/edit"), params, 
    					this.httpUtil.headers())
      				.map(this.httpUtil.extrairDados)
	                .catch(this.httpUtil.processarErros);
	}

	excluir(id: number) {

		return this.http.delete(this.httpUtil.url(this.path + '/delete/' + id), 
						this.httpUtil.headers())
	                .map(this.httpUtil.extrairDados)
	                .catch(this.httpUtil.processarErros);
	}

	buscarPorId(id: number): Observable<Usuario> {

		return this.http.get(this.httpUtil.url(this.path + '/' + id), 
						this.httpUtil.headers())
	                .map(this.httpUtil.extrairDados)
	                .catch(this.httpUtil.processarErros);
	}
}