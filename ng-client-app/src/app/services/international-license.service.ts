import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { INTERNATIONAL_API_ENDPOINTS } from '../environments/endpoints/international-license.endpoints';

@Injectable({
  providedIn: 'root',
})
export class InternationlLicenseService {
  constructor(private http: HttpClient) {}

  all(): Observable<> {
    return this.http.get(INTERNATIONAL_API_ENDPOINTS.all);
  }
}
