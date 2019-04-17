import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http'
import { IMovie } from './movie';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _httpService: Http,
    private _spinner: NgxSpinnerService) {


  }
  movie: IMovie;
  ngOnInit() {
    this._spinner.show();
    let movieId = this.route.snapshot.paramMap.get('id');
    if (movieId != 'undefined' && movieId != null) {
      this._httpService.get('/api/movie/GetMovieWithBestPrice/' + movieId).subscribe(values => {
        let moviedetail = values.json() as IMovie;
        if (moviedetail != null && moviedetail != undefined) {
          moviedetail.poster = moviedetail.poster.replace('http', 'https');
          this.movie = moviedetail;
        }
      });
    }
    this._spinner.hide();
  }

}
