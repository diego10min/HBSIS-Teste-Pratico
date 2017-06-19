import { RouterConfig } from '@angular/router'; 
import { UsuariosComponent } from './usuarios-component';

export const UsuariosRoutes: RouterConfig = [
	{ 
		path: 'usuario', 
		component: UsuariosComponent
	},
	{ 
		path: '', 
		redirectTo: '/usuario', 
		terminal: true 
	}
];