import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';

// routes
import { Home } from './page/home/home';
import { Login } from './page/login/login';
import { Tasks } from './page/tasks/tasks';

const routes: Routes = [
  { path: '', component: Home },
  { path: 'login', component: Login },
  { path: 'tasks', component: Tasks },
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
