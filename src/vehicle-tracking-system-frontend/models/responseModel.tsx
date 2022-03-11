import { ErrorModel } from "./ErrorModel";

export interface ResponseModel {
statusCode: number;
error: ErrorModel
}


/*

{
  "Data": null,
  "Error": {
    "Errors": [
      "User not found"
    ],
    "IsShow": true
  },
  "StatusCode": 404
}

*/