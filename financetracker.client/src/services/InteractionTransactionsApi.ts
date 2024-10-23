import axios from 'axios';
import { ITransactionEntity } from '../types/ITransaction';

export const GetTransactions = async (
  url: string,
): Promise<ITransactionEntity[]> => {
  const response = await axios.get(url);
  const list: ITransactionEntity[] = await response.data.list;
  return list;
};

export const GetTransactionById = async (
  url: string,
): Promise<ITransactionEntity> => {
  const response = await axios.get(url);
  const entity: ITransactionEntity = await response.data;
  return entity;
};
