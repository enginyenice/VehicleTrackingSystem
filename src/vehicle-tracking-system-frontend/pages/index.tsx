import type { NextPage } from "next";
import Link from "next/link";
import BaseLayout from "./layouts/BaseLayout";

const Home: NextPage = () => {
  return (
    <BaseLayout>
      <div className="text-center mt-5">
        <h1>Vehicle Tracking System</h1>
        <p className="lead">
          Please login to the system to track your vehicles.
        </p>
          <Link href="/login"><span className="btn w-25 btn-success">Login</span></Link>
      </div>
    </BaseLayout>
  );
};

export default Home;
