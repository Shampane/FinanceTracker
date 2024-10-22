import axios from 'axios';
import { ITransactionEntity } from '../types/ITransaction';

export const GetTransactions = async (): Promise<ITransactionEntity[]> => {
  const response = await axios.get('http://localhost:8080/Transactions');
  const list: ITransactionEntity[] = response.data.list;
  return list;
};
