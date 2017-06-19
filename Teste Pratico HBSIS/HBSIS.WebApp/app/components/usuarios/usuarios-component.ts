import { Component } from '@angular/core';
import { Usuario } from '../.././models/usuario';
import { UsuarioService } from '../.././services/usuario-service';
import { OnInit } from '@angular/core';
import { Router, ROUTER_DIRECTIVES } from '@angular/router';
import { ModalUtilComponent } from '../utils/modal-util-component';
import { ModalPersisteUsuarioComponent } from './modal-persiste-usuario-component';

@Component({
	selector: 'usuario',
	templateUrl: 'app/views/usuario/usuario.html',
	providers: [ UsuarioService],
	directives: [ ROUTER_DIRECTIVES, ModalUtilComponent, ModalPersisteUsuarioComponent ]
})
export class UsuariosComponent implements OnInit {

	private usuarios: Usuario[];
	private usuario: Usuario;
	private idExcluir: number;
	private msgErro: string;

	constructor(private router: Router, private usuarioService: UsuarioService) {
	} 

	showModal(usu:Usuario) {
		this.msgErro = "";
        if(usu){
			this.usuario = <Usuario> JSON.parse(JSON.stringify(usu));
		}else{
			this.usuario = new Usuario();
		}
    }

	onAtualizaUsuarios(usu: Usuario[]){
		this.usuarios = usu;
	}

	listarTodos() {
		this.usuarioService.listarTodos()
				.subscribe(
                	usuarios => this.usuarios = usuarios,
                	error  => this.msgErro = error);
	}

	ngOnInit() {
		this.listarTodos();
	}

	excluir(id: number) {
 		this.idExcluir = id;
 	}

 	onExcluir() {
 		this.usuarioService.excluir(this.idExcluir)
 			.subscribe(
                	data  => this.listarTodos(),
                	error => this.msgErro = error);
 		this.idExcluir = -1;
 	}

	atualizar() {
		this.usuarioService.atualizar(this.usuario)
			.subscribe(
                	usuario => this.router.navigate(['/usuario']),
                	error => this.msgErro = error);
	}
}