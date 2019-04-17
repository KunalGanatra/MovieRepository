import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { IMovie } from './movie';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  constructor(private _httpService: Http,
    private _spinner: NgxSpinnerService) { }
  movies: IMovie[] = [];
  ngOnInit() {
    this._spinner.show();
    this._httpService.get('/api/movie/GetMovies').subscribe(values => {
      this.movies = this.rewriteImageUrls(values.json()) as IMovie[];
      this._spinner.hide();
    });
  }

  rewriteImageUrls(movies): IMovie[] {

    if (movies != null && movies != 'undefined') {
      for ( var movie of movies) {
        movie.poster = movie.poster.replace('http', 'https');
      }
    }
    return movies;
  }

}
