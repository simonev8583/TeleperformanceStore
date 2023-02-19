import { Credentials } from "../../models/security/credentials.model";
import { SecurityActionTypes } from "./security.types";
import securityService from "./security.service";
import { Dispatch } from "redux";
import { Person } from "../../models/person/person.model";

class SecurityAction {
  loginAction = (credentials: Credentials) => async (dispatch: Dispatch) => {
    const promise = securityService.signIn(credentials);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: SecurityActionTypes.SIGN_IN, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  registerAction = (person: Person) => async (dispatch: Dispatch) => {
    const promise = securityService.signUp(person);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: SecurityActionTypes.SIGN_UP, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };
}

export default new SecurityAction();
