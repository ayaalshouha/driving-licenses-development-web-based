import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DETAINED_LICENSE_API_ENDPOINT } from '../environments/endpoints/detained-license.endpoints';
import { DetainedLicense } from '../models/detained-license.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class DetainedLicenseService {
  constructor(private http: HttpClient) {}

  all(): Observable<DetainedLicense[]> {
    return this.http.get<DetainedLicense[]>(DETAINED_LICENSE_API_ENDPOINT.all);
  }
}
