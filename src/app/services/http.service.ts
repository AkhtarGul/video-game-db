import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { APIResponse, Game } from '../Game';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http:HttpClient) { }
  ordering:string='';
  search?:string=''
  apiEnd='Games';
  getAllGame(sort:string,search?:string) : Observable<APIResponse<Game>>{
let params= new HttpParams().set('ordering',this.ordering)

if(this.search){
  params= new HttpParams().set('ordering',this.ordering).set('search',this.search);
}
return this.http.get<APIResponse<Game>>(`${environment.BaseUrl}`+`${this.apiEnd}`);
  }
}
