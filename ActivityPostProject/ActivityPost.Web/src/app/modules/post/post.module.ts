import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MomentModule } from 'angular2-moment';
import { TinymceModule } from 'angular2-tinymce';
import { FormsModule } from '@angular/forms';

import { PostListComponent } from './components/post-list.component';
import { PostDetailComponent } from './components/post-detail.component';

import { CoreModule } from '../core/core.module';

@NgModule({
  imports: [
    TinymceModule.withConfig({
    }),
    CoreModule,
    CommonModule,
    MomentModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'list', component: PostListComponent },
      { path: 'details/:id', component: PostDetailComponent },
      { path: 'details', component: PostDetailComponent }
    ])
  ],
  declarations: [
    PostListComponent,
    PostDetailComponent
  ],
  providers: [
  ]
})
export class PostModule { }
