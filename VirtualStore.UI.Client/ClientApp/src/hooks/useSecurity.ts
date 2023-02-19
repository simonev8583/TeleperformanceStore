import securitySelector from "../store/security/security.selector";
import { Credentials } from "../models/security/credentials.model";
import securityAction from "../store/security/security.action";
import { useDispatch, useSelector } from "react-redux";
import { Person } from "../models/person/person.model";

export const useSecurity = () => {
  const userInSession = useSelector(securitySelector.getSessionStatus);
  const userRegister = useSelector(securitySelector.isRegister);

  const dispatch = useDispatch();

  const authenticate = (credentials: Credentials) => {
    dispatch(securityAction.loginAction(credentials));
  };

  const register = (person: Person) => {
    dispatch(securityAction.registerAction(person));
  };

  return {
    authenticate,
    userInSession,
    register,
    userRegister,
  };
};
