import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app.routes';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { NotFoundComponent } from './modules/errors-page/not-found/not-found.component';
import { InternalServerComponent } from './modules/errors-page/internal-server/internal-server.component';
import { MenuComponent } from './modules/core/components/index';

import {
  PostService,
  ErrorHandlerService,
  EnvironmentUrlService
} from './modules/core/services';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    InternalServerComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    PostService,
    ErrorHandlerService,
    EnvironmentUrlService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
