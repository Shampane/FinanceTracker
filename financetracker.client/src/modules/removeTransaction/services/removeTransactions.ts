import axios from 'axios';

export class RemoveTransactions {
  public remove = async (url: string): Promise<void> => {
    try {
      await axios.delete(url);
    } catch (ex) {
      throw ex;
    }
  };
}
