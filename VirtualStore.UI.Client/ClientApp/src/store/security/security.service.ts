import { Credentials } from "../../models/security/credentials.model";
import { Person } from "../../models/person/person.model";
import BaseService from "../baseService";

class SecurityService extends BaseService {
  private readonly routes = {
    signUp: "/v1/Person",
    signIn: "/v1/Security/SignIn",
  };

  async signUp(person: Person) {
    const url = this.routes.signUp;

    return this.post(url, person);
  }

  async signIn(credentials: Credentials) {
    const url = this.routes.signIn;

    return this.post(url, credentials);
  }
}

export default new SecurityService();
