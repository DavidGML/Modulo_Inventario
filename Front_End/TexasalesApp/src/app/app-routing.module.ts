import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrademarkComponent } from './trademark/trademark.component';

const routes: Routes = [
  { path: '', redirectTo: '/trademark', pathMatch: 'full' },
  { path: 'trademark', component: TrademarkComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
