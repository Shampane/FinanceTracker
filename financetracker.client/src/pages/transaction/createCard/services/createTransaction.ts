import axios from 'axios';
import { ICreateTransactionEntity } from '../../../../types/ICreateTransactionEntity';

export class CreateTransactions {
  public create = async (
    url: string,
    entity: ICreateTransactionEntity,
  ): Promise<void> => {
    await axios.post(url, entity);
  };
}
