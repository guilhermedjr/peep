defmodule MediaServerWeb.PeepMediaControllerTest do
  use MediaServerWeb.ConnCase

  alias MediaServer.PeepMediaContent
  alias MediaServer.PeepMediaContent.PeepMedia

  @create_attrs %{
    index: 42,
    media: "some media",
    media_type: 42,
    peep: "7488a646-e31f-11e4-aace-600308960662"
  }
  @update_attrs %{
    index: 43,
    media: "some updated media",
    media_type: 43,
    peep: "7488a646-e31f-11e4-aace-600308960668"
  }
  @invalid_attrs %{index: nil, media: nil, media_type: nil, peep: nil}

  def fixture(:peep_media) do
    {:ok, peep_media} = PeepMediaContent.create_peep_media(@create_attrs)
    peep_media
  end

  setup %{conn: conn} do
    {:ok, conn: put_req_header(conn, "accept", "application/json")}
  end

  describe "index" do
    test "lists all peep_media", %{conn: conn} do
      conn = get(conn, Routes.peep_media_path(conn, :index))
      assert json_response(conn, 200)["data"] == []
    end
  end

  describe "create peep_media" do
    test "renders peep_media when data is valid", %{conn: conn} do
      conn = post(conn, Routes.peep_media_path(conn, :create), peep_media: @create_attrs)
      assert %{"id" => id} = json_response(conn, 201)["data"]

      conn = get(conn, Routes.peep_media_path(conn, :show, id))

      assert %{
               "id" => id,
               "index" => 42,
               "media" => "some media",
               "media_type" => 42,
               "peep" => "7488a646-e31f-11e4-aace-600308960662"
             } = json_response(conn, 200)["data"]
    end

    test "renders errors when data is invalid", %{conn: conn} do
      conn = post(conn, Routes.peep_media_path(conn, :create), peep_media: @invalid_attrs)
      assert json_response(conn, 422)["errors"] != %{}
    end
  end

  describe "update peep_media" do
    setup [:create_peep_media]

    test "renders peep_media when data is valid", %{conn: conn, peep_media: %PeepMedia{id: id} = peep_media} do
      conn = put(conn, Routes.peep_media_path(conn, :update, peep_media), peep_media: @update_attrs)
      assert %{"id" => ^id} = json_response(conn, 200)["data"]

      conn = get(conn, Routes.peep_media_path(conn, :show, id))

      assert %{
               "id" => id,
               "index" => 43,
               "media" => "some updated media",
               "media_type" => 43,
               "peep" => "7488a646-e31f-11e4-aace-600308960668"
             } = json_response(conn, 200)["data"]
    end

    test "renders errors when data is invalid", %{conn: conn, peep_media: peep_media} do
      conn = put(conn, Routes.peep_media_path(conn, :update, peep_media), peep_media: @invalid_attrs)
      assert json_response(conn, 422)["errors"] != %{}
    end
  end

  describe "delete peep_media" do
    setup [:create_peep_media]

    test "deletes chosen peep_media", %{conn: conn, peep_media: peep_media} do
      conn = delete(conn, Routes.peep_media_path(conn, :delete, peep_media))
      assert response(conn, 204)

      assert_error_sent 404, fn ->
        get(conn, Routes.peep_media_path(conn, :show, peep_media))
      end
    end
  end

  defp create_peep_media(_) do
    peep_media = fixture(:peep_media)
    %{peep_media: peep_media}
  end
end
