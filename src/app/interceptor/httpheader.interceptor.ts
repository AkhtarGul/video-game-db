import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpHeaderInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // return next.handle(req);
 // Clone the request to add the new header.
 const authReq = req.clone({headers: req.headers.set('x-api-key', 'MY_TOKEN_VALUE'),
 setParams:{
   key:'9900a9720d31dfd5fdb4352700c'
 }

});
 // Pass on the cloned request instead of the original request.
 return next.handle(authReq);
  }
}
