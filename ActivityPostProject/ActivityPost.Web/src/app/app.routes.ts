import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AppCustomPreloader } from './app-routing-loader';
import { HomeComponent } from './modules/home/home.component';
import { NotFoundComponent } from './modules/errors-page/not-found/not-found.component';
import { InternalServerComponent } from './modules/errors-page/internal-server/internal-server.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'post',
      loadChildren: './modules/post/post.module#PostModule',
      data: { preload: true }
    },
    { path: '500', component: InternalServerComponent },
    { path: '404', component : NotFoundComponent},
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: AppCustomPreloader })], // Using our own custom preloader
  exports: [RouterModule],
  providers: [AppCustomPreloader]
})
export class AppRoutingModule { }
