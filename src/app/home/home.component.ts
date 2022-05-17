import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { APIResponse, Game } from '../Game';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private activateRoute:ActivatedRoute,private httpSrv:HttpService) {
    this.activateRoute.paramMap.subscribe(para=>{
      let search=para.get('game-search');
      console.log(search);
      if(search){
        this.searchGame('metacrit',search);
      }
      else{
        this.searchGame('metacrit');
      }
    })
   }

   public sort:string='';
   public games:Array<Game>=[];
  ngOnInit(): void {

  }


searchGame(sort:string,search?:string){
  this.httpSrv.getAllGame(sort,search).subscribe((res:APIResponse<Game>)=>{

    this.games=res.results;
    console.log('Api Games',this.games);
  })
}
}
