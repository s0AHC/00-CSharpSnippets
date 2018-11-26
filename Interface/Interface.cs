
    public class 动物
    {
        public virtual void 进食()
        {
        }

        public virtual void 繁殖()
        {
        }
    }

public interface I哺乳类
    {
        void 哺乳();
    }

    public interface I灵长类
    {
        void 使用工具();
    }

    public interface I人类
    {
        void 政治活动();
    }

    public class 狗 : 动物, I哺乳类
    {
        public override void 进食()
        {
            base.进食();
        }

        public override void 繁殖()
        {
            base.繁殖();
        }

        public void 哺乳()
        {
        }
    }

    public class 大猩猩:动物, I哺乳类, I灵长类
    {
        public void 哺乳()
        {
        }
 
        public void 使用工具()
        {
        }
    }

    public class 人:动物, I哺乳类, I灵长类, I人类
    {
        public void 哺乳()
        {
        }

        public void 使用工具()
        {
        }

        public void 政治活动()
        {
        }
    }
	
	//上面的代码没有体现接口继承自另一个接口