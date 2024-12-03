import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { COUNTRY_API_ENDPOINT } from '../environments/endpoints/country.endpoint';
import { Observable, tap } from 'rxjs';
import { table } from 'console';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private http: HttpClient) {}

  AllCountries(): Observable<string[]> {
    return this.http.get<string[]>(COUNTRY_API_ENDPOINT.allCountries);
  }
}
