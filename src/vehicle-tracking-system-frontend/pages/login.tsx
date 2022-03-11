import React, { useEffect } from "react";
import BaseLayout from "./layouts/BaseLayout";
import AuthenticationService from "../services/AuthenticationService";
import { LoginModel } from "../models/auth/loginModel";
import { useRouter } from 'next/router';
import { ItemResponseModel } from "../models/itemResponseModel";
import { TokenModel } from "../models/auth/tokenModel";
export default function Login() {


  const router = useRouter();
  const submit = async (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      let authService = new AuthenticationService();
      let model : LoginModel = {
            username: e.currentTarget.username.value,
            password: e.currentTarget.password.value
      };
      let tokenModel : ItemResponseModel<TokenModel> = await authService.Login(model);
      if(tokenModel.error === null && tokenModel.data.token !== null) {
        localStorage.setItem("token", tokenModel.data.token);
        localStorage.setItem("expiration", tokenModel.data.expiration);
        router.push("/panel");
      }
  }

useEffect(() => {
if(localStorage.getItem("token") !== null) {
  router.push("/panel");
}
})

  return (
    <BaseLayout>
      <div className="row d-flex justify-content-center">
        <div className="col col-md-4">
          <form onSubmit={submit}>
            <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
            <div className="form-floating">
              <input
                type="text"
                className="form-control mb-2 mt-2"
                id="username"
                placeholder="username"
                autoComplete="off"
              />
              <label htmlFor="username">Username</label>
            </div>
            <div className="form-floating">
              <input
                type="password"
                className="form-control mb-2 mt-2"
                id="password"
                placeholder="Password"
                autoComplete="off"
              />
              <label htmlFor="password">Password</label>
            </div>
            <button
              className="w-100 btn btn-lg btn-success mb-2 mt-2"
              type="submit"
            >
              Sign in
            </button>
          </form>
        </div>
      </div>
    </BaseLayout>
  );
}
