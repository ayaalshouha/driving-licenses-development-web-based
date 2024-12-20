import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { INTERNATIONAL_API_ENDPOINTS } from '../environments/endpoints/international-license.endpoints';
import { InternationalLicense } from '../models/internationl-license.model';

@Injectable({
  providedIn: 'root',
})
export class InternationlLicenseService {
  constructor(private http: HttpClient) {}

  all(): Observable<InternationalLicense[]> {
    return this.http.get<InternationalLicense[]>(
      INTERNATIONAL_API_ENDPOINTS.all
    );
  }
}
