import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './Register';
import { SaveVitalsComponent, AllVitalsComponent } from './vitals';
import { AuthGuard } from './_helpers';

const routes: Routes = [
  { path: '', component: SaveVitalsComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'savevitals',
    component: SaveVitalsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'getvitals',
    component: AllVitalsComponent,
    canActivate: [AuthGuard],
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
