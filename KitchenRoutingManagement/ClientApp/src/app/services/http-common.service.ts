import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";

@Injectable()
export class HttpCommonService {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private apiBaseUrl: string) {
  }

  loadCollection(apiName: string): Observable<any> {
    // We need to update apiBaseURL : TODO
    // return this.http.get(this.apiBaseUrl + apiName)

    return this.http.get(apiName)
      .pipe(map((responseData: any) => {
        return responseData;
      }),
        catchError(error => {
          return throwError('Something went wrong!');
        })
      );
  }

  PostRequest(apiName: string, model: any) {
    const headerOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(apiName, JSON.stringify(model), headerOptions)
      .pipe(map((res: Response) => {
        if (res) {
          return [{ status: res.status, json: res.json() }]
        }
      }),
        catchError(error => {
          console.log(error);
          return throwError('Something went wrong!');
        })
      );
  }

  delete(apiName: string, id: any) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {
        id: id
      }
    }

    return this.http.delete(apiName, options).subscribe(s => {
      console.log(s);
    })
  }

  put(apiName: string) {
    this.http.put<any>(apiName, null)
      .subscribe(s => { console.log(s); });
  }
}
