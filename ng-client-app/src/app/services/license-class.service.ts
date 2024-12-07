import { Injectable } from '@angular/core';
import { LICENSE_CLASS_API_ENDPOINT } from '../environments/endpoints/licenseClass.endpoint';
import { HttpClient } from '@angular/common/http';
import { LicenseClass } from '../models/license-class.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class LicenseClassService {
  constructor(private http: HttpClient) {}
  getLicenseClass(ID: number): Observable<LicenseClass> {
    return this.http.get<LicenseClass>(
      `${LICENSE_CLASS_API_ENDPOINT.read}${ID}`
    );
  }
  getAllClasses(): Observable<LicenseClass[]> {
    return this.http.get<LicenseClass[]>(LICENSE_CLASS_API_ENDPOINT.allClasses);
  }
}
