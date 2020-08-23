export interface DtoDefaultResponse {
  statusCode: number;
  message: string;
}

export class DtoDefaultResponseModel implements DtoDefaultResponse {
  statusCode: number;
  message: string;
}
