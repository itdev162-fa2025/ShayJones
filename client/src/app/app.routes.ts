import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { ViewPostComponent } from './view-post/view-post.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'create', component: CreatePostComponent},
    {path: 'post/id', component: ViewPostComponent},
    {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }

