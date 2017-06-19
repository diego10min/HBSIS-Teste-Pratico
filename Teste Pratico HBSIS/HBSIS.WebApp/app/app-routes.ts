import { provideRouter, RouterConfig } from '@angular/router'; 
import { UsuariosRoutes } from './components/usuarios/usuarios-routes';

export const routes: RouterConfig = [
	...UsuariosRoutes
]; 

export const APP_ROUTER_PROVIDERS = [ 
	provideRouter(routes)
];