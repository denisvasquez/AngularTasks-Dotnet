import { Routes } from '@angular/router';

// routes
import { Home } from './page/home/home';
import { Login } from './page/login/login';
import { Signin } from './page/signin/signin';
import { Tasks } from './page/tasks/tasks';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'login', component: Login },
  { path: 'signin', component: Signin },
  { path: 'tasks', component: Tasks },
  { path: '**', redirectTo: '' }
];
