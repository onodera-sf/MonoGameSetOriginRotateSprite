using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SetOriginRotateSprite
{
	/// <summary>
	/// ゲームメインクラス
	/// </summary>
	public class Game1 : Game
	{
    /// <summary>
    /// グラフィックデバイス管理クラス
    /// </summary>
    private readonly GraphicsDeviceManager _graphics = null;

    /// <summary>
    /// スプライトのバッチ化クラス
    /// </summary>
    private SpriteBatch _spriteBatch = null;

    /// <summary>
    /// テクスチャー
    /// </summary>
    private Texture2D _texture = null;

    /// <summary>
    /// テクスチャーの中心座標
    /// </summary>
    private Vector2 _textureCenter = Vector2.Zero;

    /// <summary>
    /// リアルタイムに増加する回転量
    /// </summary>
    private float _realRotate = 0.0f;


    /// <summary>
    /// GameMain コンストラクタ
    /// </summary>
    public Game1()
    {
      // グラフィックデバイス管理クラスの作成
      _graphics = new GraphicsDeviceManager(this);

      // ゲームコンテンツのルートディレクトリを設定
      Content.RootDirectory = "Content";

      // マウスカーソルを表示
      IsMouseVisible = true;
    }

    /// <summary>
    /// ゲームが始まる前の初期化処理を行うメソッド
    /// グラフィック以外のデータの読み込み、コンポーネントの初期化を行う
    /// </summary>
    protected override void Initialize()
    {
      // TODO: ここに初期化ロジックを書いてください

      // コンポーネントの初期化などを行います
      base.Initialize();
    }

    /// <summary>
    /// ゲームが始まるときに一回だけ呼ばれ
    /// すべてのゲームコンテンツを読み込みます
    /// </summary>
    protected override void LoadContent()
    {
      // テクスチャーを描画するためのスプライトバッチクラスを作成します
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // テクスチャーをコンテンツパイプラインから読み込む
      _texture = Content.Load<Texture2D>("Texture");

      // テクスチャーの中心座標を取得
      _textureCenter = new Vector2(_texture.Width / 2, _texture.Height / 2);
    }

    /// <summary>
    /// ゲームが終了するときに一回だけ呼ばれ
    /// すべてのゲームコンテンツをアンロードします
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: ContentManager で管理されていないコンテンツを
      //       ここでアンロードしてください
    }

    /// <summary>
    /// 描画以外のデータ更新等の処理を行うメソッド
    /// 主に入力処理、衝突判定などの物理計算、オーディオの再生など
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Update(GameTime gameTime)
    {
      // ゲームパッドの Back ボタン、またはキーボードの Esc キーを押したときにゲームを終了させます
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
      {
        Exit();
      }

      // 回転量を増やす
      _realRotate += (float)gameTime.ElapsedGameTime.TotalSeconds * 60.0f;

      // 登録された GameComponent を更新する
      base.Update(gameTime);
    }

    /// <summary>
    /// 描画処理を行うメソッド
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Draw(GameTime gameTime)
    {
      // 画面を指定した色でクリアします
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // スプライトの描画準備
      _spriteBatch.Begin();

      var spritePos1 = new Vector2(150.0f, 200.0f);
      var spritePos2 = new Vector2(350.0f, 200.0f);
      var spritePos3 = new Vector2(550.0f, 200.0f);

      ///// 回転軸デフォルト /////

      // 回転なし
      _spriteBatch.Draw(_texture,
         spritePos1, null, Color.White,
         0.0f, Vector2.Zero,
         1.0f, SpriteEffects.None, 0.0f);

      // 回転あり
      _spriteBatch.Draw(_texture,
         spritePos1, null, Color.White,
         MathHelper.ToRadians(_realRotate), Vector2.Zero,
         1.0f, SpriteEffects.None, 0.0f);

      ///// 回転軸指定 /////

      // 回転なし
      _spriteBatch.Draw(_texture,
         spritePos2, null, Color.White,
         0.0f, Vector2.Zero,
         1.0f, SpriteEffects.None, 0.0f);

      // 回転あり
      _spriteBatch.Draw(_texture,
         spritePos2, null, Color.White,
         MathHelper.ToRadians(_realRotate), _textureCenter,
         1.0f, SpriteEffects.None, 0.0f);

      ///// 回転軸指定、位置補正 /////

      // 回転なし
      _spriteBatch.Draw(_texture,
         spritePos3, null, Color.White,
         0.0f, Vector2.Zero,
         1.0f, SpriteEffects.None, 0.0f);

      // 回転あり
      _spriteBatch.Draw(_texture,
         spritePos3 + _textureCenter, null, Color.White,
         MathHelper.ToRadians(_realRotate), _textureCenter,
         1.0f, SpriteEffects.None, 0.0f);

      // スプライトの一括描画
      _spriteBatch.End();

      // 登録された DrawableGameComponent を描画する
      base.Draw(gameTime);
    }
  }
}
