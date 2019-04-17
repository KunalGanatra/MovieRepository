import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieListComponent } from './movie/movie-list.component'
import { MovieDetailComponent } from './movie/movie-detail.component'

const routes: Routes = [
  { path: '', component: MovieListComponent },
  { path: 'movielist', component: MovieListComponent },
  { path: 'moviedetail/:id', component: MovieDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
