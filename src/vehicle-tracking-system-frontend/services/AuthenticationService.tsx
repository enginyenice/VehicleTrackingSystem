import { LoginModel } from "../models/auth/loginModel";
import { TokenModel } from "../models/auth/tokenModel";
import { ItemResponseModel } from "../models/itemResponseModel";

export default class AuthenticationService {
  
  async Login(loginModel: LoginModel) {
    return await fetch("https://localhost:7234/api/Auth/Login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
      body: JSON.stringify(loginModel),
    })
      .then((response) => response.json())
      .then((data) => {
        let newData: ItemResponseModel<TokenModel> = data;
        return newData;
      });
  }
}
