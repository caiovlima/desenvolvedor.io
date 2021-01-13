import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { throwError } from "rxjs";
import { LocalStorageUtils } from '../utils/localstorage';

export abstract class BaseService {

  public LocalStorage = new LocalStorageUtils();

  protected UrlServiceV1: string = '';

  protected ObterHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })
    };
  }

  protected extractData(response: any) {
    return response.data || {};
  }

  protected serviceError(response: Response | any) {
    let customError: string[] = [];

    if (response instanceof HttpErrorResponse) {
      if (response.statusText === "Unknown Error") {
        customError.push("Ocorreu um Error desconhecido");
        response.error.erros = customError;
      }
    }

    return throwError(response);
  }
}
