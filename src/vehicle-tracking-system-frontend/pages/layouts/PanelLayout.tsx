import { GetServerSidePropsContext, InferGetServerSidePropsType } from "next";
import { useEffect } from "react";
import { useRouter } from "next/router";
import { TokenModel } from "../../models/auth/tokenModel";
export default function PanelLayoutPage(props: any) {
  const router = useRouter();
  useEffect(() => {
    let tokenModel: TokenModel = {
      token: localStorage?.getItem("token")!,
      expiration: localStorage.getItem("expiration")!,
    };
    if (tokenModel.token === null || tokenModel.expiration === null) {
      router.push("/");
    } else if (new Date(tokenModel.expiration) < new Date()) {
      localStorage.removeItem("token");
      localStorage.removeItem("expiration");
      router.push("/");
    }
  });
  return <>{props.children}</>;
}
