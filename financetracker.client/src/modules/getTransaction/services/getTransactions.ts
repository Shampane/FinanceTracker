import axios from 'axios';
import { ITransactionEntity } from '../../../types/ITransactionEntity';

export class GetTransactions {
  public get = async (url: string): Promise<ITransactionEntity[]> => {
    const response = await axios.get(url);
    const list: ITransactionEntity[] = await response.data.list;
    return list;
  };

  public getById = async (url: string): Promise<ITransactionEntity> => {
    const response = await axios.get(url);
    const entity: ITransactionEntity = await response.data;
    return entity;
  };
}
